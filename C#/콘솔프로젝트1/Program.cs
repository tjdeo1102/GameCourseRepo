using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using static Maze.Program;

namespace Maze
{
    internal class Program
    {
        #region Structs
        public struct Player
        {
            public Pair playerPos;
            public List<Bomb> haveBombs; //보유한 폭탄, 배열의 값은 폭파 범위
        }

        public struct Enemy
        {
            public Pair enemyPos;
            public bool isInstance;
        }

        public struct Bomb
        {
            public Pair bombCurPos; //화면 밖에 있어도 위치가 저장되어야 함 (플레이어의 이동 값도 적용시켜서 현재 위치를 저장해야됌)
            public int curTimer;
            public int originTImer;
            public BombState bombState;
        }

        public enum BombState
        {
            None, Have, Instance
        }

        public struct Explosion
        {
            public bool isActive;
            public Pair minPos;
            public Pair maxPos;
        }

        public struct Pair
        {
            public int x;
            public int y;
        }

        public struct GameData
        {
            //맵 관련 변수
            public char[,] map;
            public Pair uiPos;

            // 컨트롤 관련 변수
            public ConsoleKey inputKey;

            // 오브젝트 관련 변수
            public Player player;
            public Enemy[] enemys;
            public Bomb[] bombs;
            public Explosion[] explosions;
            public int maxEnemy;
            public int maxBombNum;
            public int killedEnemy;
            //시간 관련 변수
            public bool running;
            public int responTImer; //해당 타이머가 0인 경우, 적, 폭탄 생성

        }
        #endregion

        #region UIUtils
        /// <summary>
        /// 폭탄의 기본적인 리소스
        /// </summary>
        public struct BombBaseUI
        {
            //폭탄 대기열 창의 이미지 정보
            public Pair bombInvenImageSize;
            public string bombInvenImage;
            
        }

        // 게임 시작전 폭탄 데이터 미리 생성
        static BombBaseUI bombBaseUI = new BombBaseUI()
        {
            //bombInvenImage ="+++++++\n" +
            //                "+     +\n" +
            //                "+ --- +\n" +
            //                "+  |  +\n" +
            //                "+  |  +\n" +
            //                "+     +\n" +
            //                "+++++++\n",
            bombInvenImage = "***\n" +
                             "*B*\n" +
                             "***\n",
            bombInvenImageSize = new Pair() { x = 3, y = 3 },
        };
        

        static string CreateBombUI()
        {
            string result = "";
            //기본 UI크기만큼 UI구역 나누는 가로선(x) 추가
            for (int i = 0; i < data.map.GetLength(0); i++)
            {
                result += "=";
            }
            result += "\n";

            //폭탄 UI를 가로로 잇기 위해 세로 크기 + 2 만큼 반복
            int y = bombBaseUI.bombInvenImageSize.y;
            int x = bombBaseUI.bombInvenImageSize.x;
            for (int i = 0; i < y+1; i++)
            {
                //폭탄 보유 개수만큼 폭탄 대기열창 생성
                foreach (Bomb bomb in data.player.haveBombs)
                {
                    if (bomb.bombState == BombState.Have)
                    {
                        //문자열 이미지 가로 크기만큼씩 추가
                        for (int k = 0; k < x; k++)
                        {
                            if (i < y) // 폭탄 이미지 추가
                            {

                                result += bombBaseUI.bombInvenImage[i * (x + 1) + k]; // 3행, 2열접근  ==> (i*(가로 사이즈 + 1(\n처리)) + k)
                            }
                            else // 폭탄 사거리 정보 추가
                            {
                                if ((x / 2) == k) //중간 위치
                                {
                                    result += bomb.curTimer.ToString();
                                }
                                else
                                {
                                    result += " ";
                                }
                            }
                        }
                        result += " "; //이미지 끼리 분리되도록 공백 추가
                    }
                }
                
                result += "\n";
            }

            return result;
        }
        #endregion

        #region RenderUtils
        static void Render()
        {
            Console.Clear();
            for (int i = 0; i < data.map.GetLength(0); i++)
            {
                for (int j = 0; j < data.map.GetLength(1); j++)
                {
                    data.map[i, j] = ' ';
                }
            }
            UIToMap();
            ObjectsToMap();

            PrintMap();
        }

        static void PrintMap()
        {
            // 맵 출력
            for (int y = 0; y < data.map.GetLength(1); y++)
            {
                for (int x = 0; x < data.map.GetLength(0); x++)
                {
                    switch (data.map[x, y])
                    {
                        //정수로만 저장되는 열거형이므로 char로 캐스팅
                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(data.map[x, y]);
                            Console.ResetColor();
                            break;
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(data.map[x, y]);
                            Console.ResetColor();
                            break;
                        default:
                            Console.Write(data.map[x, y]);
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        static void UIToMap()
        {
            // UI 요소 생성 및 map 데이터에 추가
            string ui = CreateBombUI();
            Pair uiCurPos = data.uiPos;
            foreach (char c in ui)
            {
                //줄바꿈이 있는 경우, 현재 위치를 y를 1증가, x를 0으로 초기화, x가 맵의 사이즈를 넘길 경우 줄 바꿈 (Ex. 맵 사이즈 x: 0~63, 입력되는 x가 64인 경우, 줄바꿈)
                if (c == '\n' || uiCurPos.x > data.map.GetLength(0))
                {
                    uiCurPos.x = 0;
                    uiCurPos.y++;
                    continue;
                }
                else //c를 map에 넣고, x를 1씩 증가
                {
                    data.map[uiCurPos.x, uiCurPos.y] = c;
                    uiCurPos.x++;
                }
            }

        }

        static void ObjectsToMap()
        {
            //플레이어의 현재 위치에 따른 플레이어 추가
            data.map[data.player.playerPos.x, data.player.playerPos.y] = 'P';

            //적들의 현재 위치에 따른 적들 추가
            foreach (Enemy enemy in data.enemys)
            {
                if (enemy.isInstance == false) continue;

                data.map[enemy.enemyPos.x, enemy.enemyPos.y] = 'E'; //적이 겹치는 위치에 있는 경우, 겹치는 적들의 이동경로가 같아지므로 하나로 합쳐져도 무방
            }

            //폭탄의 상태에 따른 폭탄 추가
            foreach (Bomb bomb in data.bombs)
            {
                if (bomb.bombState == BombState.Instance)
                {
                    data.map[bomb.bombCurPos.x, bomb.bombCurPos.y] = 'B';
                }

            }

            //폭파의 상태에 따른 폭파 추가
            foreach (Explosion explosion in data.explosions)
            {
                if(explosion.isActive == false) continue;
                //폭파 이미지 구현 필요
                for (int i = explosion.minPos.x; i<= explosion.maxPos.x; i++)
                {
                    for (int j = explosion.minPos.y; j < explosion.maxPos.y; j++)
                    {
                        data.map[i, j] = '*';
                    }
                }
            }
        }

        #endregion

        #region MathUtils
        static int Abs(int x)
        {
            if (x < 0) return -x;
            else return x;
        }

        static int Max(int x, int y)
        {
            return x > y ? x : y;
        }

        static Pair CorrectValidPosInMap(Pair pos)
        {
            if (pos.x < 0) pos.x = 0;
            if (pos.y < 0) pos.y = 0;
            if (pos.x > data.map.GetLength(0)) pos.x = data.map.GetLength(0);
            if (pos.y > data.map.GetLength(1)) pos.y = data.map.GetLength(1);
            return pos;
        }
        #endregion


        static GameData data;

        static void Main(string[] args)
        {
            data = new GameData();
            Start();

            while (data.running)
            {
                Render();
                if( Input() == true)
                {
                    Update();
                }
            }

            End();

        }

        static void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 40);
            data = new GameData();

            data.running = true;
            data.map = new char[40, 40]; // 40x32크기의 게임 화면, 밑의 32 ~ 40까지는 폭탄 대기열 ui

            data.uiPos = new Pair() { x = 0, y = 32 }; // ui가 위치할 위치, 좌상단 위치

            data.player = new Player() { playerPos = new Pair() { x = 20, y = 16 }, haveBombs = new List<Bomb>()}; //초기 플레이어 상태 정의
            for (int i = 0; i < 8; i++) //초기 폭탄 대기열들 생성
            {
                data.player.haveBombs.Add(new Bomb() { bombState = BombState.None });
            }
            data.maxEnemy = 4;
            data.maxBombNum = 16;
            data.enemys = new Enemy[data.maxEnemy];
            for (int i = 0; i < data.enemys.Length; i++)
            {
                data.enemys[i].isInstance = false;
            }

            data.bombs = new Bomb[data.maxBombNum]; // 맵에서 생성 가능한 최대 폭탄개수
            data.explosions = new Explosion[data.maxBombNum]; //폭파 개수도 최대 64개

            data.killedEnemy = 0;

            data.responTImer = 2;

            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("=                                 =");
            Console.WriteLine("=           폭탄 던지기           =");
            Console.WriteLine("=                                 =");
            Console.WriteLine("=            게임 설명            =");
            Console.WriteLine("= 폭탄을 설치하여 적을 쓰러뜨려라 =");
            Console.WriteLine("=       이동: W,A,S,D,화살표      =");
            Console.WriteLine("=  폭탄 설치:   SpaceBar          =");
            Console.WriteLine("=                                 =");
            Console.WriteLine("= 이동 및 폭탄 설치 시, 1초씩 진행=");
            Console.WriteLine("=  2초마다, 폭탄 추가 및 적 생성  =");
            Console.WriteLine("=  폭탄의 사거리는 타이머에 비례  =");
            Console.WriteLine("=   현재 보유 중인 폭탄은 하단에  =");
            Console.WriteLine("===================================");
            Console.WriteLine();
            Console.WriteLine(" 계속하려면 아무키나 누르세요  ");
            Console.ReadKey();
        }

        static void End()
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=            게임 오버!            =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine($" 적 처치 수: {data.killedEnemy}");
        }


        #region GameLogics
        static bool Input()
        {
            data.inputKey = Console.ReadKey(true).Key;

            switch (data.inputKey)
            { //키입력 유효성 검사
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    return true;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    return true;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    return true;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    return true;
                case ConsoleKey.Spacebar:
                    return BombInstantiate();
                default:
                    return false;
            }
        }

        static void Update()
        {
            //입력이 있는 경우에만, 게임 로직들 업데이트
            if (data.inputKey != ConsoleKey.None)
            {
                TimerUpdate();
                Move();
                CheckGameClear();
            }
        }

        static void TimerUpdate()
        {
            //리스폰 타이머 체크
            data.responTImer--;

            if (data.responTImer <= 0)
            {
                //적 생성
                for (int i = 0; i < data.enemys.Length; i++)
                {
                    if (data.enemys[i].isInstance == true) continue;
                    data.enemys[i].isInstance = true;

                    int x = data.player.playerPos.x;
                    int y = data.player.playerPos.y;
                    while (x == data.player.playerPos.x && y == data.player.playerPos.y) //플레이어와 다른 위치 값을 얻도록 만듬
                    {
                        x = new Random().Next(0, data.map.GetLength(0));
                        y = new Random().Next(0, data.uiPos.y); //세로는 UI 영역이 아닌 부분까지
                    }

                    data.enemys[i].enemyPos = new Pair() { x = x, y= y};
                    break;
                }

                //폭탄 대기열이 비어있는 경우에만 폭탄 대기열에 폭탄 추가
                for (int i = 0;i < data.player.haveBombs.Count;i++)
                {
                    
                    if (data.player.haveBombs[i].bombState == BombState.None)
                    {
                        int time = new Random().Next(4, 8);
                        data.player.haveBombs[i] = new Bomb() { originTImer = time, curTimer = time, bombState = BombState.Have }; // 4~7초 사이의 폭파 시간 가짐
                        break;
                    }
                }

                //타이머 초기화
                data.responTImer = 2;
            }

            //폭탄 타이머 체크하며, 타이머가 다 된 경우에, 폭파
            //기존의 폭파배열 전부 비활성화 후, 새로 할당
            for (int i=0;i<data.explosions.Length; i++)
            {
                data.explosions[i].isActive = false;
            }

            //폭파 객체를 추가
            for (int i = 0; i < data.bombs.Length; i++)
            {
                if (data.bombs[i].bombState == BombState.Instance) //인스턴스화 된 폭탄에 대해서만
                {
                    data.bombs[i].curTimer--;
                    if (data.bombs[i].curTimer <= 0)
                    {
                        data.bombs[i].bombState = BombState.None; //폭탄 제거
                        Bomb bomb = data.bombs[i];
                        //폭파 위치 및 폭파 사이즈 조정(왼쪽 상단을 기준으로)
                        int dis = data.bombs[i].originTImer - 2; //폭탄은 기다리는 시간 - 2 의 사거리
                        Pair minPos = CorrectValidPosInMap(new Pair() { x = bomb.bombCurPos.x - dis, y = bomb.bombCurPos.y - dis });
                        Pair maxPos = CorrectValidPosInMap(new Pair() { x = bomb.bombCurPos.x + dis, y = bomb.bombCurPos.y + dis });

                        data.explosions[i] = new Explosion() { isActive = true, minPos = minPos, maxPos = maxPos };
                    }
                }
            }
        }

        static bool BombInstantiate()
        {
            //폭탄 대기열의 첫번째 폭탄을 확인하여 갖고 있는 지 여부 확인
            var bomb = data.player.haveBombs[0];
            if (bomb.bombState != BombState.Have) return false;

            //인스턴스된 폭탄들 중 현재 자리와 겹친 것이 설치되어있는 경우 리턴
            foreach (var bombInMap in data.bombs)
            {
                if (bombInMap.bombState != BombState.Instance) continue;
                if (bombInMap.bombCurPos.x == data.player.playerPos.x &&
                    bombInMap.bombCurPos.y == data.player.playerPos.y)
                {
                    return false;
                }
            }

            //폭탄 생성
            for (int i =0;i<data.bombs.Length;i++)
            {
                if (data.bombs[i].bombState == BombState.Instance) continue;
                data.bombs[i].bombState = BombState.Instance;
                data.bombs[i].originTImer = data.player.haveBombs[0].originTImer;
                data.bombs[i].curTimer = data.player.haveBombs[0].curTimer + 1; //직후에 업데이트에서 폭탄 시간을 줄이므로 +1 조정
                data.bombs[i].bombCurPos = data.player.playerPos;

                data.player.haveBombs.RemoveAt(0);
                break;
            }
            return true;
        }

        static void Move()
        {
            //플레이어 입력에 따른 움직임 업데이트
            switch (data.inputKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    MoveTo(0, -1, ref data.player.playerPos);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    MoveTo(0, 1, ref data.player.playerPos);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    MoveTo(-1, 0, ref data.player.playerPos);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    MoveTo(1, 0, ref data.player.playerPos);
                    break;
            }

            EnemyMove();
        }
        static void EnemyMove()
        {
            int pX = data.player.playerPos.x;
            int pY = data.player.playerPos.y;
            //각각의 enemy에 대해 움직임 업데이트
            for (int i=0; i<data.enemys.Length; i++)
            {
                if (data.enemys[i].isInstance == false) continue;

                //플레이어와의 거리 차이
                int difX = pX - data.enemys[i].enemyPos.x;
                int difY = pY - data.enemys[i].enemyPos.y;

                int absDifX = Abs(difX);
                int absDifY = Abs(difY);

                if (difX == 0 && difY == 0) { continue; } //차이가 없을 때 continue

                //더 차이가 큰 축으로 1만큼 이동
                if (absDifX > absDifY)
                {
                    MoveTo(difX / absDifX, 0, ref data.enemys[i].enemyPos);
                }
                else
                {
                    MoveTo(0, difY / absDifY, ref data.enemys[i].enemyPos);
                }
            }
        }

        static void MoveTo(int x_dis, int y_dis,ref Pair originPos)
        {
            Pair next = new Pair() { x = originPos.x + x_dis, y = originPos.y + y_dis };

            int sizeX = data.map.GetLength(0);
            int sizeY = data.uiPos.y; //ui 범위는 제외한 세로 길이 까지

            // 맵의 범위를 벗어나면 리턴
            if (next.x < 0 || next.y < 0 || next.x >= sizeX || next.y >= sizeY) { return; }

            originPos = next;
        }

        static void CheckGameClear()
        {
            Pair playerPos = data.player.playerPos;
            // 각각의 enemy의 위치에 따라, 게임 종료 확인
            foreach (Enemy enemy in data.enemys)
            {
                if (enemy.enemyPos.x == playerPos.x &&
                    enemy.enemyPos.y == playerPos.y)
                {
                    data.running = false;
                }
            }

            // 폭파 범위에 있는 경우에 따라, 게임 종료 확인
            foreach (Explosion explosion in data.explosions)
            {
                if (explosion.isActive == false) continue; //폭탄 비활성화의 경우 건너뛰기 

                if ((playerPos.x >= explosion.minPos.x && playerPos.y >= explosion.minPos.y) &&
                   (playerPos.x <= explosion.maxPos.x && playerPos.y <= explosion.maxPos.y))
                {
                    data.running = false;
                }

                //만약 폭파범위에 적이 있는 경우, 적 오브젝트 제거
                for (int i = 0; i < data.enemys.Length; i++)
                {
                    if (data.enemys[i].isInstance == true)
                    {
                        var enemyPos = data.enemys[i].enemyPos;
                        if ((enemyPos.x >= explosion.minPos.x && enemyPos.y >= explosion.minPos.y) &&
                            (enemyPos.x <= explosion.maxPos.x && enemyPos.y <= explosion.maxPos.y))
                        {
                            data.enemys[i].isInstance = false;
                            data.killedEnemy++;
                        }
                    }   
                }
            }

        }

        #endregion
    }
}

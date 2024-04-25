using System.Xml.Linq;

namespace ConsoleApp2
{
    class Program
    {
        //스탯
        static string Name = ""; //
        static int Level = 1; // 
        static string Job = ""; // 
        static int Attack = 10; // 
        static int Defense = 5; // 
        static int HP = 100; // 
        static int MP = 10; // 
        static int Gold = 1500; // 

        //리스트
        static List<Item> inventory = new List<Item>();
        static List<Item> equippedItems = new List<Item>();
        static List<Item> shopItems = new List<Item>();
        static List<int> purchasedItemIDs = new List<int>();

        static void Main() //진입점 의미가 없어져버린
        {
            Console.WriteLine("★스파르타 던전★");
            Console.WriteLine("게임을 시작합니다.");
            Console.Write("캐릭터 이름을 입력해주세요:");
            Name = Console.ReadLine();
            InitializeShopItems();
            StartScene();
        }

        //직업 선택
        static void StartScene()
        {
            Console.WriteLine("1.전사 2.마법사 3.궁수");

            int select = NumberInput();

            switch (select) //직업에 따라 스탯이 다르다
            {
                case 1:
                    Job = "전사";
                    Defense += 3;
                    break;
                case 2:
                    Job = "마법사";
                    HP += 10;
                    MP += 5;
                    break;
                case 3:
                    Job = "궁수";
                    Attack += 3;
                    break;
                case 320840:
                    Job = "-";
                    Gold += 100000;
                    break;
                default:
                    Console.WriteLine("잘못된 번호를 입력했습니다.");
                    Console.WriteLine("아무 키나 눌러주세요...");
                    Console.ReadKey();
                    Console.Clear();
                    StartScene();
                    break;
            }
            StartGame(); //게임으로 이동
        }

        //마을 입장
        static public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전");
            Console.WriteLine();

            int select = NumberInput();

            switch (select)
            {
                case 1:
                    ShowStatus(); //상태보기
                    break;
                case 2:
                    ShowInventory(); //인벤토리
                    break;
                case 3:
                    ShowShop(); //상점
                    break;
                case 4:
                    enterdungeon(); //던전 - 미구현
                    break;
                default:
                    Console.WriteLine("잘못된 번호를 입력했습니다.");
                    Console.WriteLine("아무 키나 눌러주세요...");
                    Console.ReadKey();
                    Console.Clear();
                    StartGame();
                    break;
            }
        }

        //상태창
        static public void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. 01");
            Console.WriteLine();
            Console.WriteLine(Name + Job);
            Console.WriteLine();
            Console.WriteLine("공격력 : " + Attack);
            Console.WriteLine("방어력 : " + Defense);
            Console.WriteLine("체 력 : " + HP);
            Console.WriteLine("Gold: " + Gold + " G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            //화면 이동
            int select = NumberInput();

            if (select == 0)
            {
                StartGame();
            }
            else
            {
                Console.WriteLine("잘못된 번호를 입력했습니다.");
                Console.WriteLine("아무 키나 눌러주세요...");
                Console.ReadKey();
                Console.Clear();
                ShowStatus();
            }
        }

        //인벤토리
        static public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            inventoryItemList();
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int select = NumberInput();

            switch (select)
            {
                case 1:
                    Console.Clear();
                    EquipItem();
                    break;
                case 0:
                    Console.Clear();
                    StartGame();
                    break;
                default:
                    Console.WriteLine("잘못된 번호를 입력했습니다.");
                    Console.WriteLine("아무 키나 눌러주세요...");
                    Console.ReadKey();
                    Console.Clear();
                    ShowInventory();
                    break;
            }
        }

        //장착 관리
        static public void EquipItem()
        {
            Console.Clear();
            Console.WriteLine("장착할 아이템을 선택하세요:");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            inventoryItemList();
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int select = NumberInput();

            if (select == 0)
            {
                Console.Clear();
                ShowInventory();
            }
            else if (select >= 0 && select <= inventory.Count)
            {
                EquipSelected(select - 1);
            }
            else
            {
                Console.WriteLine("잘못된 번호를 입력했습니다.");
                Console.WriteLine("아무 키나 눌러주세요...");
                Console.ReadKey();
                Console.Clear();
                EquipItem();
            }
        }

        //가진 아이템 목록을 불러온다
        static void inventoryItemList()
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {inventory[i].Name}  |  {inventory[i].Type} {inventory[i].Effect}  |  {inventory[i].Description})");
            }
            if (inventory.Count >= 1)
            {
                for (int i = 0; i < equippedItems.Count; i++)
                {
                    Console.WriteLine($"[E]{inventory.Count + 1}. {inventory[i].Name}  |  {inventory[i].Type} {inventory[i].Effect}  |  {inventory[i].Description})");
                }
            }
            {
                for (int i = 0; i < equippedItems.Count; i++)
                {
                    Console.WriteLine($"[E]{i + 1}. {equippedItems[i].Name}  |  {equippedItems[i].Type} {equippedItems[i].Effect}  |  {equippedItems[i].Description})");
                }
            }
        }

        //아이템 장착
        static void EquipSelected(int index)
        {
            Item selected = inventory[index];

            if (selected.Type == "방어력")
            {
                Defense += selected.Effect;
            }
            else if (selected.Type == "공격력")
            {
                Attack += selected.Effect;
            }

            if (selected.Type != null)
            {
                equippedItems.Add(selected);
            }

            Console.WriteLine($"{inventory[index].Name}을(를) 장착했습니다!");
            inventory.RemoveAt(index);

            Console.WriteLine("아무 키나 눌러주세요...");
            Console.ReadKey();
            Console.Clear();
            EquipItem();
        }

        //상점 입장
        static public void ShowShop()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("상점주인:뭐 찾는거라도 있나?");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(Gold + " G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            ShopItemList();
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            //화면 이동
            int select = NumberInput();


            switch (select)
            {
                case 1:
                    Console.Clear();
                    BuyItem();
                    break;
                case 0:
                    Console.Clear();
                    StartGame();
                    break;
                default:
                    Console.WriteLine("잘못된 번호를 입력했습니다.");
                    Console.WriteLine("아무 키나 눌러주세요...");
                    Console.ReadKey();
                    Console.Clear();
                    ShowShop();
                    break;
            }
        }

        //상점 아이템 목록
        static void ShopItemList()
        {
            for (int i = 0; i < shopItems.Count; i++)
            {
                bool purchased = IsItemPurchased(shopItems[i]);
                string purchaseStatus = purchased ? " 구매 완료" : $" {shopItems[i].Price} G";
                Console.WriteLine($"{i + 1}. {shopItems[i].Name}  |  {shopItems[i].Type} {shopItems[i].Effect}  |  {shopItems[i].Description}  |  {purchaseStatus}");
            }
        }

        //아이템 구매창
        static public void BuyItem()
        {
            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(Gold + " G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            ShopItemList();
            Console.WriteLine();
            Console.WriteLine("0. 뒤로 가기");

            int select = NumberInput();

            //switch (select)
            //{
            //    case 0:
            //        Console.Clear();
            //        ShowShop();
            //        break;
            //    case 1:
            //        BuyItemProcess(shopItems[0]);
            //        break;
            //    case 2:
            //        BuyItemProcess(shopItems[1]);
            //        break;
            //    case 3:
            //        BuyItemProcess(shopItems[2]);
            //        break;
            //    case 4:
            //        BuyItemProcess(shopItems[3]);
            //        break;
            //    case 5:
            //        BuyItemProcess(shopItems[4]);
            //        break;
            //    case 6:
            //        BuyItemProcess(shopItems[5]);
            //        break;
            //    default:
            //        Console.WriteLine("잘못된 번호를 입력했습니다.");
            //        Console.WriteLine("아무 키나 눌러주세요...");
            //        Console.ReadKey();
            //        Console.Clear();
            //        BuyItem();
            //        break;
            //}

            if (select == 0)
            {
                Console.Clear();
                ShowShop();
                return;
            }

            Item selectedItem = shopItems[select - 1];

            if (IsItemPurchased(selectedItem))
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
                Console.WriteLine("아무 키나 눌러주세요...");
                Console.ReadKey();
                Console.Clear();
                BuyItem();
                return;
            }
            BuyItemProcess(selectedItem);
        }

        //아이템을 추가 하며 초기화 시키는 공간
        static void InitializeShopItems()
        {
            shopItems.Add(new Item(1, "방어력", "수련자 갑옷", 1000, 5, "수련에 도움을 주는 갑옷입니다."));
            shopItems.Add(new Item(2, "방어력", "무쇠갑옷", 2000, 9, "무쇠로 만들어져 튼튼한 갑옷입니다."));
            shopItems.Add(new Item(3, "방어력", "스파르타의 갑옷", 3500, 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다."));
            shopItems.Add(new Item(4, "공격력", "낡은 검", 600, 2, "쉽게 볼 수 있는 낡은 검입니다."));
            shopItems.Add(new Item(5, "공격력", "청동 도끼", 1500, 5, "어디선가 사용됐던 것 같은 도끼입니다."));
            shopItems.Add(new Item(6, "공격력", "스파르타의 창", 2500, 7, "스파르타의 전사들이 사용했다는 전설의 창입니다."));
        }

        //아이템을 구매하는 과정
        static void BuyItemProcess(Item item)
        {
            if (Gold >= item.Price)
            {
                Gold -= item.Price;
                inventory.Add(item);
                purchasedItemIDs.Add(item.ID);
                Console.WriteLine($"{item.Name}을(를) 구매했습니다!");
            }
            else
            {
                Console.WriteLine("골드가 부족합니다!");
            }

            Console.WriteLine("아무 키나 눌러주세요...");
            Console.ReadKey();
            Console.Clear();
            BuyItem();
        }

        // 구매한거 있는지 확인
        static bool IsItemPurchased(Item item)
        {
            return purchasedItemIDs.Contains(item.ID); //참, 거짓 반환
        }

        static void enterdungeon()
        {
            Console.Clear();
            Console.WriteLine("괴물들의 소리가 들린다...");
            Console.WriteLine();
            Console.WriteLine("미구현 상태입니다.");
            Console.WriteLine("마을로 돌아갑니다.");
            Console.WriteLine();
            Console.WriteLine("아무 키나 눌러주세요...");
            Console.ReadKey();
            Console.Clear();
            StartGame();
        }

        //아이템 정보 저장
        class Item
        {
            public int ID { get; }
            public string Type { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public int Effect { get; set; }
            public string Description { get; set; }

            public Item(int id, string type, string name, int price, int effect, string description)
            {
                ID = id;
                Type = type;
                Name = name;
                Price = price;
                Effect = effect;
                Description = description;
            }
        }

        //숫자 확인
        public static int NumberInput() //값을 입력하고 숫자인지 확인 및 그 값을 반환해준다.
        {
            int number;

            while (true)
            {
                Console.WriteLine("원하시는 것을 입력해주세요.");
                Console.Write(">> ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out number)) //문자열을 정수로 변환, 그 값이 true이면 실행한다.
                {
                    return number; // 함수를 종료하고 값을 반환한다.
                }
                else
                {
                    Console.WriteLine("숫자를 입력하세요.");
                    Console.WriteLine("아무 키나 눌러주세요...");
                    Console.WriteLine();
                }
            }
        }
    }
}
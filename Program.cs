using System;

namespace pic7
{
    class Program
    {
        static void Main(string[] args)
        {
            BonusCardSystem bonusCardSystem = new BonusCardSystem();
            bonusCardSystem.bonusCards = bonusCardSystem.ReadBonusCards();

            bool isActive = true;
            while (isActive)
            {
                Console.WriteLine("Выберите необходимое действие:");
                Console.WriteLine("1. Просмотр карточки по номеру");
                Console.WriteLine("2. Добавление карточки");
                Console.WriteLine("3. Совершение покупки с помощью карточки");
                Console.WriteLine("4. Просмотреть все карточки");
                Console.WriteLine("5. Выход");


                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            bonusCardSystem.ShowCardInfo();
                            break;
                        }
                    case "2":
                        {
                            bonusCardSystem.AddBonusCard();
                            break;
                        }
                    case "3":
                        {
                            bonusCardSystem.ProcessPurchase();
                            break;
                        }
                    case "4":
                        {
                            bonusCardSystem.ShowAllBonusCards();
                            break;
                        }

                    case "5":
                        {
                            isActive = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Некорректно введенная команда");
                            break;
                        }
                }
            }
        }
    }
}

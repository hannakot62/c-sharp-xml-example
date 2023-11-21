using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace pic7
{
    public partial class BonusCardSystem : XMLWorker<BonusCard>
    {
        protected override List<BonusCard> GetData(string filepath)
        {
            XDocument doc = XDocument.Load(filepath);

            // Пример запроса LINQ to XML для получения списка книг определенного жанра (например, "Роман")
            List<BonusCard> bonusCards = doc.Descendants("card")
            .Select(card => new BonusCard
            {
                Number = card.Element("number").Value,
                Bonuses = int.Parse(card.Element("bonuses").Value)
            })
            .ToList();
            return bonusCards;
        }
        protected override void SetData(List<BonusCard> list, string filepath)
        {
            XDocument xmlDoc = new XDocument(
            new XElement("cards",
                    from card in list
                    select new XElement("card",
                    new XElement("number", card.Number),
                    new XElement("bonuses", card.Bonuses))));

            // Сохраняем XML в файл
            xmlDoc.Save(filepath);
        }

        public List<BonusCard> ReadBonusCards()
        {
            string filePath = "data.xml";
            return GetData(filePath);
        }

        public void SaveBonusCards()
        {
            string filePath = "data.xml";
            SetData(bonusCards, filePath);
        }

        public void ShowAllBonusCards()
        {
            for (int i = 0; i < bonusCards.Count; i++)
            {
                Console.WriteLine("------------", i + 1, "------------");
                Console.WriteLine(bonusCards[i].ShowCard());

            }
        }

        public void AddBonusCard()
        {
            Console.WriteLine("Enter card number");
            string number = Console.ReadLine();
            ValidationDelegate lengthValidation = new ValidationDelegate(ValidateLength);
            if (lengthValidation(number))
            {
                bonusCards.Add(new BonusCard(number, 0));
                SaveBonusCards();
                Console.WriteLine("Added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid card number");
            }
        }

        public void ShowCardInfo()
        {
            Console.WriteLine("Enter card number");
            string number = Console.ReadLine();
            ValidationDelegate lengthValidation = new ValidationDelegate(ValidateLength);
            Console.WriteLine("\n");
            if (lengthValidation(number))
            {
                BonusCard found = bonusCards.FirstOrDefault(card => card.Number == number);
                if(found != null)
                {
                    Console.WriteLine(found.ShowCard());
                }
                else
                {
                    Console.WriteLine("No such card :(\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid card number\n");
            }
        }

        public void ProcessPurchase()
        {
            Console.WriteLine("Enter card number");
            string number = Console.ReadLine();
            ValidationDelegate lengthValidation = new ValidationDelegate(ValidateLength);
            if (lengthValidation(number))
            {
                BonusCard found = bonusCards.FirstOrDefault(card => card.Number == number);
                if (found != null)
                {
                    Console.WriteLine("Enter the purchase sum: ");
                    int sum = int.Parse(Console.ReadLine());
                    int bonusesNew = (int)(sum / 100 * 4);
                    ShowReceipt(found.Bonuses, bonusesNew, sum);
                    found.Bonuses = bonusesNew;
                    SaveBonusCards();
                }
                else
                {
                    Console.WriteLine("No such card :(\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid card number");
            }
        }

        public void ShowReceipt(int bonuses, int bonusesNew, int purchaseSum)
        {
            Console.WriteLine("\nPurchase sum: "+ purchaseSum);
            Console.WriteLine("Bonuses available: "+ bonuses);
            Console.WriteLine("Accrued bonus: "+ bonusesNew);
            Console.WriteLine("=======================================================");
            Console.WriteLine("Total: "+ (purchaseSum - bonuses));
        }
    }
}
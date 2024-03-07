namespace _03._Cards
{
    class Program
    {
        public static void Main(string[] args)
        {
            string facesInput = "2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A";
            List<string> faces = new List<string>(facesInput.Split(", "));
            string suitsInput = "S, H, D, C";
            List<string> suits = new List<string>(suitsInput.Split(", "));
            List<Card> cards = new List<Card>();
            string[] input = Console.ReadLine().Split(", ");
            for (int i = 0; i < input.Length; i++)
            {
                string face = null;
                string suit = null;
                try
                {

                    string[] newInput = input[i].Split();
                    if (facesInput.Contains(newInput[0]))
                    {
                        face = newInput[0];
                    }
                    else
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    if (suitsInput.Contains(newInput[1]))
                    {
                        suit = newInput[1];
                    }
                    else
                    {
                        throw new ArgumentException("Invalid card!");
                    }
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (var card in cards)
            {
                Console.Write($"[{card.Face}{card.Suit}] ");
            }
        }
    }

    public class Card
    {
        public string Face { get; set; }

        public string Suit { get; set; }

        public Card(string face, string suit)
        {

            this.Face = face;
            if (suit == "S")
            {
                this.Suit = "\u2660";
            }
            else if (suit == "H")
            {
                this.Suit = "\u2665";
            }
            else if (suit == "D")
            {
                this.Suit = "\u2666";
            }
            else if (suit == "C")
            {
                this.Suit = "\u2663";
            }
        }

        public void Print()
        {
            Console.Write($"[{this.Face}{this.Suit}] ");
        }
    }
}

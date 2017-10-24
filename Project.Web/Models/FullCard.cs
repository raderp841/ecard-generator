using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class FullCard
    {
        public FullCard(CardTemplate temp, GreetingCard gc)
        {
            this.Template = temp;
            this.Card = gc;
        }

        public CardTemplate Template { get; set; } = new CardTemplate();
        public GreetingCard Card { get; set; } = new GreetingCard();
    }
}
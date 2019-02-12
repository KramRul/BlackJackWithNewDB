using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.BLL.Models
{
    public class CardViewModel
    {
        public int Id { get; set; }

        public Rank Rank { get; set; }

        public Suite Suite { get; set; }

        public bool IsFaceUp { get; set; }

        public int HandId { get; set; }

        public Hand Hand { get; set; }
    }
}




/*ProductsViews
    GetAllProductsView => List< ProductGetAllProductsViewItem >
    ProductGetAllProductsViewItem

    GetByIdProductsView => 

    CreateProductsView => 


    UpdateProductsView*/

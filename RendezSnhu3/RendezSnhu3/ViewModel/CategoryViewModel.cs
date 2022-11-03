using RendezSnhu3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace RendezSnhu3.ViewModel
{
    public class CategoryViewModel
    {
        public IList<Category> CatList { get; set; }

        public CategoryViewModel()
        {
            try
            {
                CatList = new ObservableCollection<Category>
                {
                    new Category { CategoryId = 1, CategoryName = "Sports" },
                    new Category { CategoryId = 2, CategoryName = "Gaming" }
                };


            }
            catch (Exception ex)
            {

            }
        }


    }
}

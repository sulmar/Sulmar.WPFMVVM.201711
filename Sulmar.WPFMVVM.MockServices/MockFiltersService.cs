using System;
using System.Collections.Generic;
using System.Text;
using Sulmar.WPFMVVM.ShopPracz.Models;
using System.Linq;
using Sulmar.WPFMVVM.ShopPracz.Services;

namespace Sulmar.WPFMVVM.ShopPracz.MockServices
{
    public class MockFiltersService : IFiltersService
    {
        private IList<Filter> filters;

        public MockFiltersService()
        {
            filters = new List<Filter>
            {
                new Filter
                {
                    Id = 1,
                    Name = "Filtr 1",
                    Segments = new List<Segment>
                    {
                        new Segment { Name = "A" },
                        new Segment { Name = "AB" },
                        new Segment { Name = "B" },
                        new Segment { Name = "AC" },
                        new Segment { Name = "BD" },
                        new Segment { Name = "C" },
                        new Segment { Name = "CD" },
                        new Segment { Name = "D" },

                    }
                },

                new Filter
                {
                    Id = 2,
                    Name = "Filtr 2",
                    Segments = new List<Segment>
                    {
                        new Segment { Name = "A" },
                        new Segment { Name = "AB" },
                        new Segment { Name = "B" },
                        new Segment { Name = "AC" },
                        new Segment { Name = "BD" },
                        new Segment { Name = "C" },
                        new Segment { Name = "CD" },
                        new Segment { Name = "D" },

                    }
                },

            };
        }

        public Filter Get(int id)
        {
            return filters.SingleOrDefault(f => f.Id == id);
        }

        public void Update(Filter filter)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sulmar.WPFMVVM.ShopPracz.Models
{
    public class Filter : Base
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<Segment> Segments { get; set; }
    }

    public class Segment : Base
    {
        public string Name { get; set; }

        #region State

        private SegmentState state;
        public SegmentState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }


    public enum SegmentState
    {
        OK,
        FailureA,
        FailureB
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    class Graph<TN,TL>
    {
        enum State { sUnexplored = 0, sFrontier, sClosed };

        class Node<TN>
        {
            List<Link<TL>> mvLinks;

            public State State { get; set; }
            public double ExpectedCost { get; set; }
            public TN Content { get; set; }


            internal Node(TN content)
            {
                Content = content;
            }

        }

        class Link<TL>
        {
            Node<TN> mStartNode;
            Node<TN> mEndNode;

            public State State { get; set; }
            public TL Content { get; set; }

            internal Link(TL content)
            {
                Content = content;
            }
        }
    }
}

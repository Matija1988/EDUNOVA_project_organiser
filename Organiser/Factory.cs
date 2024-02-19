using Organiser.ObjectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organiser
{
    public static class Factory
    {
                

        public static IProject ProjectFactory()
        {
           
            return new Project();
        }

        public static IMember MemberFactory()
        {
            return new Member();
        }

        public static IActivity ActivityFactory()
        {
            return new Activity();
        }
    }
}

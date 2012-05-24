using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;

namespace WCFServiceWebRole1
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {

        List<DirectoryEntry> entries = new List<DirectoryEntry>();

        private testDB1Entities testDBContext;

        public Service1()
        {
            testDBContext = new testDB1Entities();

            var numOfFriends = testDBContext.TestTable_friends.Count();
        }
        

        #region Implementation of IDirectoryService

        public void AddDirectoryEntry(DirectoryEntry entry)
        {
            TestTable_friends newFriend = new TestTable_friends()
            {
                FirstName = entry.FirstName,
                LastName = entry.LastName,
                Addr = entry.Address,
                PhoneNumber = entry.PhoneNumber
            };

            testDBContext.TestTable_friends.AddObject(newFriend);
            testDBContext.SaveChanges();
        }

        public List<DirectoryEntry> GetDirectoryEntries()
        {
            var retVal = from friend in testDBContext.TestTable_friends
                         select new DirectoryEntry()
                         {
                             FirstName = friend.FirstName,
                             LastName = friend.LastName,
                             PhoneNumber = friend.PhoneNumber,
                             Address = friend.Addr
                         };

            return retVal.ToList();
        }

        public DirectoryEntry GetDirectoryEntry(string fname, string lname)
        {
            //experimenting with queries right now. this should be fixed up

            //var friendInQuestion = from f in testDBContext.TestTable_friends
            //                       where f.FirstName == fname && f.LastName == lname
            //                       select f;

            //var finalFriend = friendInQuestion.First();

            ////alternatively
            //var finalFriend2 = testDBContext.TestTable_friends.Single(f => f.FirstName == fname && f.LastName == lname);

            //DirectoryEntry retVal = new DirectoryEntry()
            //{
            //    FirstName = finalFriend2.FirstName,
            //    LastName = finalFriend2.LastName,
            //    PhoneNumber = finalFriend2.PhoneNumber,
            //    Address = finalFriend2.Addr
            //};

            //return retVal;

            //again alternatively you could 

            var retVal1 = (from friend in testDBContext.TestTable_friends
                           where friend.FirstName == fname && friend.LastName == lname
                           select new DirectoryEntry
                           {
                               FirstName = friend.FirstName,
                               LastName = friend.LastName,
                               PhoneNumber = friend.PhoneNumber,
                               Address = friend.Addr
                           }).Single();

            return retVal1;
            
        }

        public void RemoveDirectoryEntry(string firstName, string lastName)
        {
            var entityToDelete = testDBContext.TestTable_friends.Single(friend => friend.FirstName == firstName
                                                                                && friend.LastName == lastName);

            testDBContext.TestTable_friends.DeleteObject(entityToDelete);
            testDBContext.SaveChanges();
        }


        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;
using VaktarSkipan.BLL.DB;

namespace VaktarSkipan.BLL.Entities
{
    public class DatabaseModels
    {
        private VaktarSkipanEntities vse = new VaktarSkipanEntities();

        public List<Person> allPeoples
        {
            get { return vse.Person.ToList(); }
        }

        public bool addWorker(Person p)
        {
            Person tmp = vse.Person.Find(p.PersonID);

            if (tmp == null)
            {
                vse.Person.Add(p);
                vse.SaveChanges();

                return true;
            }
            else 
            {
                return false;
            }
        }

        public IEnumerable<Vaktir> allJobs
        {
            get { return vse.Vaktir; }
        }

        public void addJob(Vaktir vakt)
        {
            vse.Vaktir.Add(vakt);
            vse.SaveChanges();
        }

        public bool takeJob(Vaktir vakt)
        {
            bool canWork = true;

            var vaktToTake =
            from v in vse.Vaktir
            where v.VaktID == vakt.VaktID
            select v;
            var checkvakt =
                from v in vse.Vaktir
                where v.Date == vakt.Date
                where v.PersonID == LoggedIn.username
                select v;

            foreach(var v in checkvakt)
            {
                if ((vakt.Start > v.Start && vakt.Start < v.End)&&(vakt.End > v.Start && vakt.End < v.End))
                    canWork = false;
            }
            if (canWork)
            {
                foreach (var v in vaktToTake)
                {
                    v.isFree = false;
                    v.PersonID = LoggedIn.username;
                }

                try
                {
                    vse.SaveChanges();
                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine(e);
                }
            }
            return canWork;

        }

        public void releaseJob(Vaktir vakt)
        {

            var vaktToRelease =
            from v in vse.Vaktir
            where v.VaktID == vakt.VaktID
            select v;
            foreach (var v in vaktToRelease)
                v.isFree = true;

            try
            {
                vse.SaveChanges();
            }
            /*catch (System.Exception e)
            {
                System.Console.WriteLine(e);
            }*/
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} throws Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }

        }


        public Person getPerson(string id)
        {
            return vse.Person.Find(id);
        }

        public Vaktir getVakt(int id)
        {
            Vaktir returnVakt = vse.Vaktir.Find(id);

            return returnVakt;
        }

        public void updateJob(Vaktir v)
        {
            if(v != null)
            {
                vse.Vaktir.Find(v.VaktID).Date = v.Date;
                vse.Vaktir.Find(v.VaktID).End = v.End;
                vse.Vaktir.Find(v.VaktID).isFree = v.isFree;
                vse.Vaktir.Find(v.VaktID).Person = v.Person;
                vse.Vaktir.Find(v.VaktID).PersonID = v.PersonID;
                vse.Vaktir.Find(v.VaktID).Start = v.Start;
                vse.Vaktir.Find(v.VaktID).Type = v.Type;

                vse.SaveChanges();

            }
        }

        public bool deleteJob(Vaktir dVakt)
        {
            Vaktir tmpVakt = vse.Vaktir.Find(dVakt.VaktID);
            if(tmpVakt != null)
            { 
                vse.Vaktir.Remove(dVakt);
                vse.SaveChanges();
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool updatePerson(Person p)
        {
            Person tmp = vse.Person.Find(p.PersonID);

            if(tmp != null)
            {

                vse.Person.Find(p.PersonID).FirstName = p.FirstName;
                vse.Person.Find(p.PersonID).LastName = p.LastName;
                vse.Person.Find(p.PersonID).Telephone = p.Telephone;
                vse.Person.Find(p.PersonID).PersonID = p.PersonID;
                vse.Person.Find(p.PersonID).Password = p.Password;
                vse.SaveChanges();
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void deletePerson(Person p)
        {
            if(p != null)
            {
                vse.Person.Remove(p);
                vse.SaveChanges();
            }
        }

        public bool LoginMethod(string username, string password)
        {
            Person user = allPeoples.Find(x => x.PersonID == username);

            if(user.Password == password)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

    }
}

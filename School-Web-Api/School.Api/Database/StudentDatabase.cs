using School.API.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.API.Database
{
    public class StudentDatabase
    {
        /// <summary>
        /// asta este doar baza de date, nu stie sa faca nimic, e doar dulapul ,
        /// containerul pentru studentii mei,
        /// nu stie sa adauge, sa stearga, sa caute, nu stie nimic,
        /// e doar o lista de studenti care tine studentii mei
        /// </summary>
        /// 
        public static List<Student> _database = new List<Student>();

        public List<Student> GetDatabase()
        {
            return _database;
        }

    }
}

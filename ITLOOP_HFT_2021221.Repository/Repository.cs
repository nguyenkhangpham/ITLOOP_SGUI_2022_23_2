using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ITLOOP_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext dbc;

        //Gets or sets DbContext field so the child can reach it. - TODO
        protected DbContext Dbc { get => this.dbc; set => this.dbc = value; }

        //Constructor
        public Repository(DbContext dbc)
        {
            this.dbc = dbc;
        }

        //Create
        public abstract void Insert(T entity);

        //Read
        public IQueryable<T> GetAll()
        {
            return dbc.Set<T>(); //set = its a set, it doesnt set any value
        }
        //Update

        public abstract T GetOne(int id);


        //Delete
        public abstract void Remove(int id); 

    }
}

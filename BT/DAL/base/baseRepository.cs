using BT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BT.DAL
{
    public class baseRepository : IDisposable
    {
        private dbContext context = new dbContext();
        private simpleRepository<TProjects> RProjects;
        private simpleRepository<TProjectsVersions> RProjectsVersions;
        private simpleRepository<TStatus> RStatus;

        public simpleRepository<TProjects> ProjectsRepository
        {
            get
            {
                if (this.RProjects == null)
                {
                    this.RProjects = new simpleRepository<TProjects>(context);
                }
                return RProjects;
            }
        }
        public simpleRepository<TProjectsVersions> ProjectsVersions
        {
            get
            {
                if (this.RProjectsVersions == null)
                {
                    this.RProjectsVersions = new simpleRepository<TProjectsVersions>(context);
                }
                return RProjectsVersions;
            }
        }
        public simpleRepository<TStatus> Status
        {
            get
            {
                if (this.RStatus == null)
                {
                    this.RStatus = new simpleRepository<TStatus>(context);
                }
                return RStatus;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Kariyer.Entity;
using Kariyer.Repository.Fabric;
using System;
using System.Data.Entity.Validation;
using System.Text;

namespace Kariyer.Repository
{
    public class UnitOfWork : IDisposable
    {
        private KariyerEntities context = new KariyerEntities();
        private IWindsorContainer container = null;
        private bool disposed = false;

        #region IOC Container

        private IWindsorContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = this.BootstrapContainer();
                }

                return container;
            }
        }

        private IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer().Register(

                Component.For(typeof(ICrud<>))
                .ImplementedBy(typeof(Generic<>))
                .LifeStyle.PerWebRequest
                .DynamicParameters((kernel, parametres) => parametres["Context"] = context)
                );
        }

        public T Resolve<T>()
        {
            return this.Container.Resolve<T>();
        }

        #endregion

        #region Entity Save

        public void Save()
        {
            try
            {
                if (context == null)
                {
                    throw new ArgumentNullException("context");
                }
                context.SaveChanges();
            }
            catch (DbEntityValidationException valEx)
            {
                var sbValidationError = new StringBuilder();

                foreach (var validationErrors in valEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        sbValidationError.Append(String.Format("Property: {0}, Error : {1}", validationError.PropertyName, validationError.ErrorMessage));
                        sbValidationError.Append(Environment.NewLine);
                    }
                }

                throw new Exception(sbValidationError.ToString(), valEx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region IDisposible Virtual Method

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                this.context.Dispose();
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}

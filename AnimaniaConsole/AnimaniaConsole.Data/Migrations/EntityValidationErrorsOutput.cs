using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;

namespace AnimaniaConsole.Data.Migrations
{
    public sealed class EntityValidationErrorsOutput
    {
        public static void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Error: " + sb.ToString(), ex); 
            }
        }
    }
}
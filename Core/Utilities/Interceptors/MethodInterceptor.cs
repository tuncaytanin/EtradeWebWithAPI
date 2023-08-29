using Castle.DynamicProxy;
using System;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterceptor : MethodInterceptionBaseAttribute
    {

        /// <summary>
        /// Method Çalışmadan önce
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnBefore(IInvocation invocation) 
        {

        }
        /// <summary>
        /// Method Çalışmadan Önce
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnAfter(IInvocation invocation) //before method run
        {

        }
        /// <summary>
        /// Hata Aldığında
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnException(IInvocation invocation , Exception exception) //before method run
        {

        }

        /// <summary>
        /// Başarılı olduğunda
        /// </summary>
        /// <param name="invocation"></param>
        protected virtual void OnSuccess(IInvocation invocation) //before method run
        {

        }


        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {

                invocation.Proceed();
                if (invocation.ReturnValue is Task returnValueTask)
                {
                    returnValueTask.GetAwaiter().GetResult();
                }
                if (invocation.ReturnValue is Task task && task.Exception != null)
                {
                    throw task.Exception;
                }
            }
            catch (Exception exception)
            {

                isSuccess =false;
                OnException(invocation,exception);
                throw;
            }
            finally {
                if (isSuccess)
                    OnSuccess(invocation);   
                OnAfter(invocation);
            }  

        }
    }
}

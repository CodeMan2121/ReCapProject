using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {//Burada invocation metodunu kullandık.Add, getall, update gibi metodlardan biri olarak çalıştıracağımız için o metodlarmış gibi 
         //düşünürsek örneğin add metodu olsun yani onu çalıştırsın;
            var isSuccess = true;
            //Burada metodun başında çalışır. OnBefore demek metodun başında çalıştır demek.
            //Validation veya diğer(log, cache gibi) kodları metodun başında çalıştır.
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                //Burası ise hata alırsan çalıştır demek.Yani metodu çalıştırıken hata alırsan Validation ve ya diğer(log gibi) kodları çalıştır.
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    //Metod başarılı bir şekilde çalışırsa Validation veya diğer kodları çalıştır.
                    OnSuccess(invocation);
                }
            }
            //Validation ya da diğer CrossCuttingConcerns(log, cashe, Authorization, Transaction) kodları metoddan sonra çalışır.
            OnAfter(invocation);
        }
    }
}

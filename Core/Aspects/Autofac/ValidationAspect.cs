using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterceptor
    {
        private readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Yanlış doğrulama türü");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entites = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entites)
            {
                ValidationTool.Validate(validator, entity);
            }
        }


        protected override void OnAfter(IInvocation invocation)
        {
            base.OnAfter(invocation);
        }
        protected override void OnException(IInvocation invocation, Exception exception)
        {
            base.OnException(invocation, exception);
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            base.OnSuccess(invocation);
        }


    }
}

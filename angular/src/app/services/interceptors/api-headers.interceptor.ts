import { HttpInterceptorFn } from '@angular/common/http';

export const apiHeadersInterceptor: HttpInterceptorFn = (req, next) => {
  const authReq = req.clone({headers:req.headers.set('Authorization','Bearer')});
  return next(authReq);
};

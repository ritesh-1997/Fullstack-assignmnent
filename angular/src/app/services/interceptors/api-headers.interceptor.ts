import { HttpInterceptorFn } from '@angular/common/http';

export const apiHeadersInterceptor: HttpInterceptorFn = (req, next) => {
  var auth = localStorage.getItem('Authorization')?.toString()??'';
  const authReq = req.clone({headers:req.headers.set('Authorization',auth)});
  return next(authReq);
};

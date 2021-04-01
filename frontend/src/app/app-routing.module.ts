import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './shared/component/not-found/not-found.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { EnvServiceProvider } from './services/env.service.provider';
import { ServiceEndpoint } from './services/service-endpoint';
import { AuthGuard } from './shared/authguard/auth.guard';

const loginModule = () => import('./features/login/login.module').then(x => x.LoginModule);
const homeModule = () => import('./features/home/home.module').then(x => x.HomeModule);

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', loadChildren: homeModule,
    data: {
      breadcrumb: 'Home',
    },
    canActivate: [AuthGuard]
  },
  {path: 'login', loadChildren: loginModule},
    // otherwise redirect to home
  { path: '**', component: NotFoundComponent }
];


@NgModule({
  imports: [CommonModule, HttpClientModule, RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers:[EnvServiceProvider, ServiceEndpoint]
})
export class AppRoutingModule { }

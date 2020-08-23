import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './common/services/auth.guard';

const APP_ROUTES_DEFAULT: Routes = [

    {
        path: '', component: MainComponent, data : { title : "Main" }, children: [

			{ path: 'spent',  canActivate: [AuthGuard], loadChildren: () => import('./main/spent/spent.module').then(m => m.SpentModule) },



            ]
    },



]


export const RoutingDefault: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES_DEFAULT);



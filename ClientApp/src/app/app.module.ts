import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsersListComponent } from './users-list/users-list.component';
import { PermissionsListComponent } from './permissions-list/permissions-list.component';
import { ManagementPageComponent } from './management-page/management-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsersListComponent,
    PermissionsListComponent,
    ManagementPageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'users-list', component: UsersListComponent },
      { path: 'permissions-list', component: PermissionsListComponent },
      { path: 'management-page', component: ManagementPageComponent },
      { path: '**', redirectTo: 'home' },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

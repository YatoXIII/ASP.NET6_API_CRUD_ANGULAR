import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../service/User';
import { ServiceApi } from '../service/ServiceApi'
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  providers: [ServiceApi]
})
export class UsersListComponent implements OnInit {

  public users: User[] = [];
  public user: User = new User;
  public errorMessage: string = "";
  tableMode: boolean = true;

  constructor(private usersApi: ServiceApi) { }

  ngOnInit() {
    this.user.id = -1;
    this.loadUsers();
  }

  // получаем данные через сервис
  loadUsers() {
    this.usersApi.getUsers()
      .subscribe((data) => this.users = data);
  }
  // сохранение данных
  save() {
    if (this.user.id == null) {
      this.usersApi.createUser(this.user!)
        .subscribe(data => { this.cancel() },
        error => this.errorMessage = error.message);
    } else {
      this.usersApi.updateUser(this.user!)
        .subscribe(data => { this.cancel() },
          error => this.errorMessage = error.message);
    }
  }
  editUser(u: User) {
    this.user = u;
  }
  cancel() {
    this.loadUsers(); 
    this.user = new User();
    this.user.id = -1;
    this.tableMode = true;
  }
  delete(u: User) {
    this.usersApi.deleteUser(u.id!)
      .subscribe(data => this.loadUsers());
  }
  add() {
    this.errorMessage = "";
    this.cancel();
    this.tableMode = false;
  }

}

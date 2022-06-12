import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { User } from './User';
import { Permission } from './Permission';
import { UserWithPermissions } from './UserWithPermissions';

@Injectable()
export class ServiceApi {

  private urlUsers = "/api/Users";
  private urlPermissions = "/api/Permissions";
  private urlUsersPermissions = "/api/Users/Permissions"

  constructor(private http: HttpClient) {
  }

  // Работа с Пользователем
  getUsers() {
    return this.http.get<User[]>(this.urlUsers);
  }

  getUser(id: number) {
    return this.http.get(this.urlUsers + '/' + id);
  }

  createUser(user: User) {
    return this.http.post(this.urlUsers, user);
  }

  updateUser(user: User) {
    return this.http.put(this.urlUsers, user);
  }
  deleteUser(id: number) {
    return this.http.delete(this.urlUsers + '/' + id);
  }

  // Работа с правами пользователя
  getUserWithPermissions(id: number) {
    return this.http.get(this.urlUsersPermissions + '/' + id);
  }

  updateUserPermissions(userWithPermissions: UserWithPermissions) {
    return this.http.put(this.urlUsersPermissions, userWithPermissions);
  }

  // Работа с правами
  getPermissions() {
    return this.http.get<Permission[]>(this.urlPermissions);
  }

  getPermission(id: number) {
    return this.http.get(this.urlPermissions + '/' + id);
  }

  createPermission(permission: Permission) {
    return this.http.post(this.urlPermissions, permission);
  }
  updatePermission(permission: Permission) {
    return this.http.put(this.urlPermissions, permission);
  }
  deletePermission(id: number) {
    return this.http.delete(this.urlPermissions + '/' + id);
  }
}

import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Permission } from '../service/Permission';
import { User } from '../service/User';
import { ServiceApi } from '../service/ServiceApi'
import { UserWithPermissions } from '../service/UserWithPermissions';

@Component({
  selector: 'app-management-page',
  templateUrl: './management-page.component.html',
  providers: [ServiceApi]
})
export class ManagementPageComponent implements OnInit {

  public userId: number = 0;
  public permissionId: number = 0;

  public permissions: Permission[] = [];
  public permission: Permission = new Permission;
  public userWithPermissions: UserWithPermissions = new UserWithPermissions;
  tableMode: boolean = true;

  constructor(private serviceApi: ServiceApi) { }

  ngOnInit() {
    this.loadPermissions();
  }

  // Полчение пользователя и список его прав
  loadPermissions() {
    this.userWithPermissions = new UserWithPermissions;
    this.permissions = [];
    this.serviceApi.getUserWithPermissions(this.userId)
      .subscribe((data: UserWithPermissions) => {
        this.userWithPermissions = data;
        this.permissions = this.userWithPermissions.permissions!;
      });
  }
  // Полечение информации о праве по ID
  loadPermission() {
    this.permission = new Permission;
    this.serviceApi.getPermission(this.permissionId)
      .subscribe((data: Permission) => this.permission = data);
  }
  // Добавления права в список прав пользователя
  addPermission() {

    if (this.permission == null) {
      this.cancel();
      return;
    }

    this.permissions.push(this.permission);
    this.userWithPermissions.permissions = this.permissions;
    this.serviceApi.updateUserPermissions(this.userWithPermissions)
      .subscribe(data => this.loadPermissions());

    this.cancel();
  }
  // Отмена операции добавления
  cancel() {
    this.permission = new Permission;
    this.permission.id = -1;
    this.tableMode = true;
  }
  // Удаление права из списка прав пользователя
  delete(p: Permission) {

    this.permissions.forEach((item, index) => {
      if (item.id === p.id) {
        this.permissions.splice(index, 1);
      }
    });
    this.userWithPermissions.permissions = this.permissions;

    this.serviceApi.updateUserPermissions(this.userWithPermissions)
      .subscribe(data => this.loadPermissions());
  }
  openAddForm() {
    this.permission.id = 0;
    this.loadPermission();
    this.cancel();
    this.tableMode = false;
  }
}

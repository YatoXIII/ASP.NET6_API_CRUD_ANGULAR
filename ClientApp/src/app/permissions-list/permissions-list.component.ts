import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Permission } from '../service/Permission';
import { ServiceApi } from '../service/ServiceApi'

@Component({
  selector: 'app-permissions-list',
  templateUrl: './permissions-list.component.html',
  providers: [ServiceApi]
})
export class PermissionsListComponent implements OnInit {

  public permissions: Permission[] = [];
  public permission: Permission = new Permission;
  public errorMessage: string = "";
  tableMode: boolean = true;

  constructor(private permissionsApi: ServiceApi) { }

  ngOnInit() {
    this.permission.id = -1;
    this.loadPermissions();
  }

  // получаем данные через сервис
  loadPermissions() {
    this.permissionsApi.getPermissions()
      .subscribe((data) => this.permissions = data);
  }
  // сохранение данных
  save() {
    if (this.permission.id == null) {
      this.permissionsApi.createPermission(this.permission)
        .subscribe(data => { this.cancel() },
          error => this.errorMessage = error.message);
    } else {
      this.permissionsApi.updatePermission(this.permission)
        .subscribe(data => { this.cancel() },
          error => this.errorMessage = error.message);
    }
  }
  editPermission(u: Permission) {
    this.permission = u;
  }
  cancel() {
    this.loadPermissions();
    this.permission = new Permission();
    this.permission.id = -1;
    this.tableMode = true;
  }
  delete(u: Permission) {
    this.permissionsApi.deletePermission(u.id!)
      .subscribe(data => this.loadPermissions());
  }
  add() {
    this.errorMessage = "";
    this.cancel();
    this.tableMode = false;
  }
}


"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ServiceApi = void 0;
var core_1 = require("@angular/core");
var ServiceApi = /** @class */ (function () {
    function ServiceApi(http) {
        this.http = http;
        this.urlUsers = "/api/Users";
        this.urlPermissions = "/api/Permissions";
        this.urlUsersPermissions = "/api/Users/Permissions";
    }
    // Работа с Пользователем
    ServiceApi.prototype.getUsers = function () {
        return this.http.get(this.urlUsers);
    };
    ServiceApi.prototype.getUser = function (id) {
        return this.http.get(this.urlUsers + '/' + id);
    };
    ServiceApi.prototype.createUser = function (user) {
        return this.http.post(this.urlUsers, user);
    };
    ServiceApi.prototype.updateUser = function (user) {
        return this.http.put(this.urlUsers, user);
    };
    ServiceApi.prototype.deleteUser = function (id) {
        return this.http.delete(this.urlUsers + '/' + id);
    };
    // Работа с правами пользователя
    ServiceApi.prototype.getUserWithPermissions = function (id) {
        return this.http.get(this.urlUsersPermissions + '/' + id);
    };
    ServiceApi.prototype.updateUserPermissions = function (userWithPermissions) {
        return this.http.put(this.urlUsersPermissions, userWithPermissions);
    };
    // Работа с правами
    ServiceApi.prototype.getPermissions = function () {
        return this.http.get(this.urlPermissions);
    };
    ServiceApi.prototype.getPermission = function (id) {
        return this.http.get(this.urlPermissions + '/' + id);
    };
    ServiceApi.prototype.createPermission = function (permission) {
        return this.http.post(this.urlPermissions, permission);
    };
    ServiceApi.prototype.updatePermission = function (permission) {
        return this.http.put(this.urlPermissions, permission);
    };
    ServiceApi.prototype.deletePermission = function (id) {
        return this.http.delete(this.urlPermissions + '/' + id);
    };
    ServiceApi = __decorate([
        core_1.Injectable()
    ], ServiceApi);
    return ServiceApi;
}());
exports.ServiceApi = ServiceApi;
//# sourceMappingURL=ServiceApi.js.map
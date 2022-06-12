import { Permission } from '../service/Permission';

export class UserWithPermissions {
  constructor(
    public id?: number,
    public name?: string,
    public login?: string,
    public email?: string,
    public permissions?: Permission[]  ) { }
}

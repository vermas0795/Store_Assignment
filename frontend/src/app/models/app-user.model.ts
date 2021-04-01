import { BaseModel } from './base.model';

export class AppUser extends BaseModel {
  userName: string;
  loginName: string;
  emailId: string;
  password: string;
  discount: number;
  token: string;
  role:string;
}

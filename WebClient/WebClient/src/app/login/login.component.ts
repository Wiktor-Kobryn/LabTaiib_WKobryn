import { Component } from '@angular/core';
import { UserRequestDTO } from '../models/user-request.interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  public login: string = "";
  public password: string = "";
  //public user: UserRequestDTO;

  public onUserLogin(): void {
    //login i autoryzacja
  }

}

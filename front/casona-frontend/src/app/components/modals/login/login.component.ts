import { Component, OnInit } from '@angular/core';
import { NgbModal, NgbModalOptions, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { RegisterComponent } from '../register/register.component';
import { ForgotPasswordComponent } from '../forgot-password/forgot-password.component';
import { SocialAuthService, AmazonLoginProvider } from "angularx-social-login";
import { FacebookLoginProvider, GoogleLoginProvider } from "angularx-social-login";
import { SocialUser } from "angularx-social-login";
import { User, UserTO } from 'src/app/core/models/user';
import { StorageService } from 'src/app/core/service/storage.service';
import { UserService } from 'src/app/core/service/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  user: SocialUser;
  loggedIn: boolean;
  usrTO: User = new UserTO(0, 0, '', 0, '', '', '', '', '', '', '', new Date);
  userForm: FormGroup;

  modalOption: NgbModalOptions = {
    backdrop: 'static',
    keyboard: false,
    windowClass: 'login-modal',
    centered: true
  }

  constructor(
    private authService: SocialAuthService
    , private userService: UserService
    , private storageService: StorageService
    , private _modalService: NgbModal
    , private _activeModal: NgbActiveModal
    , private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.userLogin();

    if(this.storageService.getUserProfile() > 0) {
     // this._activeModal.close(LoginComponent);
      // toast diciendo que esta loguado ya 
    }


    this.authService.authState.subscribe((user) => {
      this.user = user;
      this.loggedIn = (user != null);
      console.log(user);
      if (this.loggedIn) {
        this.usrTO.Email = user.email;
        this.usrTO.FirstName = user.firstName;
        this.usrTO.LastName = user.lastName;
        this.usrTO.Name = user.name;
        this.usrTO.PhotoUrl = user.photoUrl;
        this.usrTO.Provider = user.provider;
        this.usrTO.IdUser = 0;
        if (user.provider === 'FACEBOOK') {
          this.usrTO.IdSocial = 1;
        } else if (user.provider === 'GOOGLE') {
          this.usrTO.IdSocial = 2;
        }
        else {
          this.usrTO.IdSocial = 3;
        }
        this.usrTO.IdStatus = 1;
        this.usrTO.Password = '';
        this.usrTO.StatusName = '';

        this.userService.setCreateUser(this.usrTO).subscribe(result => {

          if (result > 0) {
            this._activeModal.close(LoginComponent);
            this.storageService.saveUserProfile(String(result));
            this.userInfo(this.storageService.getUserProfile());

          } else {
            // toast error   
          }

        });
      }
      else {
        
        //this.loggedIn = (this.storageService.getUserInfo);
        
      }

    });

  }

  userLogin() {
    this.userForm = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }


  openRegister() {
    this._activeModal.close(LoginComponent);
    const modalref = this._modalService.open(RegisterComponent, this.modalOption);
    this.authService.signOut();
  }
  openForgotPassword() {
    this._activeModal.close(LoginComponent);
    const modalref = this._modalService.open(ForgotPasswordComponent, this.modalOption);
  }
  close() {
    this._activeModal.close(LoginComponent)
  }
  getListUser() {
    
    this.userService.getListUser(this.userForm.controls['email'].value, this.userForm.controls['password'].value).subscribe(result => {

      if (result.length > 0) {
        this.storageService.saveUserProfile(String(result[0].IdUser));
        this.userInfo(this.storageService.getUserProfile());
        this._activeModal.close(LoginComponent);
      } else {
        // toast error
      }
    });
  }
  signInWithFB(): void {
    this.authService.signIn(FacebookLoginProvider.PROVIDER_ID);
  }
  signInWithGoogle(): void {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }
  signOut(): void {
    this.authService.signOut();
  }
  userInfo(idUser: number) {
    this.userService.getListUserInfo(idUser).subscribe(result => {

      if (result.length > 0) {
        this.storageService.saveUserInfo(JSON.stringify(result[0]));
      } else {
        // toast error
      }
    });

  }
}

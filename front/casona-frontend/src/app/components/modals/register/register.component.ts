import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Address, AddressTO } from 'src/app/core/models/address';
import { Phone, PhoneTO } from 'src/app/core/models/phone';
import { User, UserTO } from 'src/app/core/models/user';
import { AddressService } from 'src/app/core/service/address.service';
import { PhoneService } from 'src/app/core/service/phone.service';
import { StorageService } from 'src/app/core/service/storage.service';
import { UserService } from 'src/app/core/service/user.service';

import { MASKS, NgBrazilValidators } from 'ng-brazil';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {


  public MASKS = MASKS;

  newUser: FormGroup;
  newAddress: FormGroup;
  usrTO: User = new UserTO(0, 0, '', 0, '', '', '', '', '', '', '', new Date);
  phnTO: Phone = new PhoneTO(0, 0, 0, 0, 0);
  adrsTO: Address = new AddressTO(0, 0, 0, 0, '', 0, '', new Date);

  newUserFlag: boolean = true;
  newAddressFlag: boolean = false;

  constructor(
    private _activeModal: NgbActiveModal
    , private formBuilder: FormBuilder
    , private userService: UserService
    , private storageService: StorageService
    , private phoneService: PhoneService
    , private addresService: AddressService

  ) { }

  ngOnInit(): void {
    this.newUserform();
    this.newAddressform();
  }

  newUserform() {
    this.newUser = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      name: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(128)]],
      lastName: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(128)]],
      phone: ['', [<any>Validators.required, <any>NgBrazilValidators.telefone]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  newAddressform() {
    this.newAddress = this.formBuilder.group({
      address: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(128)]],
      cep: ['', [<any>Validators.required, <any>NgBrazilValidators.cep]],
      number: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(11)]],
      commune: ['', [Validators.required, Validators.minLength(6)]],
      idCommune: ['']
    });
  }

  close() {
    this._activeModal.close(RegisterComponent);
  }

  registerNewUser() {

    this.usrTO.Email = this.newUser.controls['email'].value;
    this.usrTO.FirstName = this.newUser.controls['name'].value;
    this.usrTO.LastName = this.newUser.controls['lastName'].value;
    this.usrTO.Password = this.newUser.controls['password'].value;
    this.usrTO.Name = this.newUser.controls['name'].value + ' ' + this.newUser.controls['lastName'].value;

    this.phnTO.Area = Number(String(this.newUser.controls['phone'].value).substring(0, 2));
    this.phnTO.Phone = Number(String(this.newUser.controls['phone'].value).substring(2, String(this.newUser.controls['phone'].value).length));
    this.userService.setCreateUser(this.usrTO).subscribe(result => {
      console.log(result);
      if (result > 0) {
        this.storageService.saveUserProfile(String(result));
        this.userInfo(this.storageService.getUserProfile());
        this.phnTO.IdUser = result;
        this.phnTO.IdStatus = 1;
        this.phoneService.setCreatePhone(this.phnTO).subscribe(res => {
          console.log(res);
          if (res > 0) {
            this.newUserFlag = false;
            this.newAddressFlag = true;
          }
        });
      } else {
        // toast error   
      }
    });

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

  getCEP() {
    this.newAddress.controls['cep'].setValue(this.newAddress.controls['cep'].value.replace(".","").replace("-",""));
    this.addresService.getCEP('https://viacep.com.br/ws/' + this.newAddress.controls['cep'].value + '/json/').subscribe(rest => {
      if (rest.logradouro) {
        this.newAddress.controls['address'].setValue(rest.logradouro);
        this.newAddress.controls['commune'].setValue(rest.bairro);
      }
      else {
        //toast error search
      }
    });
  }

  createAddress() {
    this.addresService.getCommune().subscribe(rest => {
      if (rest.filter(x => x.Commune === this.newAddress.controls['commune'].value).length === 0) {
        this.newAddress.controls['idCommune'].setValue(4);
      }
      else {
        this.newAddress.controls['idCommune'].setValue(rest.filter(x => x.Commune === this.newAddress.controls['commune'].value)[0].IdCommune);
      }


      this.adrsTO = new AddressTO(0, 0, 0, 0, '', 0, '', new Date);
      this.adrsTO.IdUser = this.storageService.getUserProfile();
      this.adrsTO.CEP = this.newAddress.controls['cep'].value;
      this.adrsTO.Commune = this.newAddress.controls['commune'].value;
      this.adrsTO.IdCommune = this.newAddress.controls['idCommune'].value;
      this.adrsTO.Address = this.newAddress.controls['address'].value + ' ' + this.newAddress.controls['number'].value;
      this.adrsTO.IdStatus = 1;
      this.addresService.setCreateAddress(this.adrsTO).subscribe(rest => {
        if (rest > 0) {
          this._activeModal.close(RegisterComponent);
        }
        else {
          //toast error create
        }

      });
      console.log(this.adrsTO);
    });

    
  }
}

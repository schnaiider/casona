import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FullLayoutComponent } from './layout/full-layout/full-layout.component';
import { HeaderComponent } from './layout/full-layout/header/header.component';
import { FooterComponent } from './layout/full-layout/footer/footer.component';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    FullLayoutComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    RouterModule,
    CommonModule
  ]
})
export class SharedModule { }

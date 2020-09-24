import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LandingPageRoutingModule } from './landing-page-routing.module';
import { LandingPageComponent } from './landing-page.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [LandingPageComponent],
  imports: [
    CommonModule,
    NgbModule,
    LandingPageRoutingModule,
  ]
})
export class LandingPageModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarlistComponent } from './components/carcore/carlist/carlist.component';
import { HttpClientModule } from '@angular/common/http';
import { MakeDropdownComponent } from './components/carcore/make-dropdown/make-dropdown.component';

@NgModule({
  declarations: [
    AppComponent,
    CarlistComponent,
    MakeDropdownComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

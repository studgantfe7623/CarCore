import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MakeDropdownComponent } from './components/carcore/make-dropdown/make-dropdown.component';

const routes: Routes = [
  {
    path: '',
    component: MakeDropdownComponent
  }
  // {
  //   path: 'carcore',
  //   component: CarcoreComponent
  // }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

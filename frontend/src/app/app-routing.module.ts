import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarcoreComponent } from './components/carcore/carcore.component';

const routes: Routes = [
  {
    path: '',
    component: CarcoreComponent
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

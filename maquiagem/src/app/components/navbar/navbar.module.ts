import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from './navbar.component';


@NgModule({
  declarations: [NavbarComponent],
  imports: [CommonModule, FormsModule, ],
  exports: [NavbarComponent]  // Exporta o componente para ser utilizado em outros módulos
})
export class NavbarModule { }

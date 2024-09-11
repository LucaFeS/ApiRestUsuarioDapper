import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home.component';
import { NavbarModule } from '../../components/navbar/navbar.module';


@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    NavbarModule,
    ReactiveFormsModule
  ],
  providers: [],  // Não é necessário incluir providers se não há serviços sendo fornecidos
  exports: []     // Adicione exportações se você deseja compartilhar componentes, diretivas, etc.
})
export class HomeModule { }

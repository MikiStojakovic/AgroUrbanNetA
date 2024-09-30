import {NgModule} from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import {NavBarComponent} from './nav-bar/nav-bar.component';

@NgModule({
  declarations: [
  ],
  imports: [
    BrowserAnimationsModule,
    AppComponent,
    NavBarComponent
  ],
  providers: [
  ],
  bootstrap: []
})
export class AppModule { }
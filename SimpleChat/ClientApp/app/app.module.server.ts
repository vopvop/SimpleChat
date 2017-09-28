import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { sharedConfig } from './app.module.shared';
import { FormsModule } from '@angular/forms';

@NgModule({
	bootstrap: sharedConfig.bootstrap,
	declarations: sharedConfig.declarations,
	imports: [
		ServerModule,
		FormsModule,
		...sharedConfig.imports
	]
})
export class AppModule { }
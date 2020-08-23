import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

import { ModalModule } from 'ngx-bootstrap/modal';
import { SpentComponent } from './spent.component';
import { SpentRoutingModule } from './spent.routing.module';

import { SpentService } from './spent.service';
import { SpentServiceFields } from './spent.service.fields';

import { ApiService } from '../../common/services/api.service';
import { CommonSharedModule } from '../../common/common-shared.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        ModalModule.forRoot(),
        CommonSharedModule,
        SpentRoutingModule,
    ],
    declarations: [
        SpentComponent
    ],
    providers: [SpentService,SpentServiceFields, ApiService],
})
export class SpentModule {


}
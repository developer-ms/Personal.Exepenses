import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SpentComponent } from './spent.component';
import { GlobalService } from '../../global.service';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "Spent" }, component: SpentComponent },
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class SpentRoutingModule {

}
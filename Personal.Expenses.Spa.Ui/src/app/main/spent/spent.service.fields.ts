import { Injectable } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { ServiceBase } from '../../common/services/service.base';

@Injectable()
export class SpentServiceFields extends ServiceBase {


	constructor() {
		super()
	}

	getKey() {
		return "Spent";
	}

	getFormControls(moreFormControls? : any) {
		var formControls = Object.assign({
      description : new FormControl(),
      spentId : new FormControl(),
		},moreFormControls || {});
		return formControls;
	}

	getFormFields(moreFormControls?: any) {
		return new FormGroup(this.getFormControls(moreFormControls));
	}

	getInfosFields(moreInfosFields? : any, useMoreInfosFields = false) {
		var defaultInfosFields = {
      description: { label: 'description', type: 'string', isKey: false, list:true  ,  },
      spentId: { label: 'spentId', type: 'int', isKey: true, list:false  ,  },
		};
		return this.mergeInfoFields(defaultInfosFields, moreInfosFields, useMoreInfosFields);
	}

}

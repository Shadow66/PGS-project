import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'categoriesPipe' })
export class CategoriesPipe implements PipeTransform {
  transform(value, args: string[]): any {
    const keys = [];
    for (const enumMember in value) {
      if (!isNaN(parseInt(enumMember, 10))) {
        const val = String(value[enumMember]).replace('_', ' & ');
        keys.push({ key: enumMember, value: val });
        // Uncomment if you want log
        // console.log('enum member: ', value[enumMember]);
      }
    }
    return keys;
  }
}

import { SkillModel } from "./skill.model";

export interface AssociateWithSkillsModel {
  associateId: any;
  name: string;
  email: boolean;
  mobile: number;
  picture: string;
  gender: string;
  statusGreen: boolean;
  statusBlue: boolean;
  statusRed: boolean;
  level1: boolean;
  level2: boolean;
  level3: boolean;
  remark: string;
  strength: string;
  weakness: string;
  skills: Array<AssociateWithSkillsModel>;
}

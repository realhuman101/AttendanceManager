import {get, post} from './request';

export async function allUsers() {
	return await get('/api/User');
}

export async function addRole(email: string, role: string) {
	return await post(`/api/User/Modify/Roles/Add/${email}&${role}`);
}

export async function removeRole(email: string, role: string) {
	return await post(`/api/User/Modify/Roles/Remove/${email}&${role}`);
}

export async function userRoles(email: string) {
	return await get(`/api/User/Roles/${email}`);
}

export async function currUser() {
	return await get(`/api/User/Current`);
}

export async function currUserRoles() {
	return await get(`/api/User/Roles/Current`);
}

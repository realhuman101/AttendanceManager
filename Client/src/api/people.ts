import {get, post} from './request';

export async function allPeople() {
	return await get('/api/People');
}

export async function personClass(id: string) {
	return await get(`/api/People/${id}/classes`);
}

export async function personRole(id: string) {
	return await get(`/api/People/${id}/role`);
}

export async function specificPerson(id: string) {
	return await get(`/api/People/${id}`);
}

export async function searchPeople(name: string) {
	return await get(`/api/People/search/${name}`);
}

export async function updatePersonStatus(id: string, state: boolean) {
	return await post(`/api/People/${id}&${state}`);
}

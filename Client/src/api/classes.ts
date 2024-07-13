import {get} from './request';

export async function allClasses() {
	return await get('/api/Classes');
}

export async function peopleInClass(id: number) {
	return await get(`/api/Classes/${id}/people`);
}

export async function specificClass(id: number) {
	return await get(`/api/Classes/${id}`);
}

import api from '../../http/api'

export interface IClient {
  id: number
  name: string
  phoneNumber: string
  email: string
  suburb: string
}

export interface IJob {
  id: number
  description: string
  price: number
  category: number
  status: number
  createdAt: Date
  clientId: number
  client: IClient
}

export interface IResponseList {
  error: boolean
  response?: IJob[]
}

class Services {
  public async GetByStatus(status: string): Promise<IResponseList> {
    return await api
      .get(`Job?status=${status}`)
      .then((response) => {
        return {
          error: false,
          response: response.data.jobs as IJob[],
        }
      })
      .catch(() => {
        return { error: true }
      })
  }
}

export default Services

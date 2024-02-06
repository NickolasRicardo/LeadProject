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

export interface IResponse {
  error: boolean
}

export interface IRequest {
  id: number
  approved: boolean
}

class Services {
  public async Update({ id, approved }: IRequest): Promise<IResponse> {
    return await api
      .put(`Job/UpdateJob`, { id, approved })
      .then(() => {
        return {
          error: false,
        }
      })
      .catch(() => {
        return { error: true }
      })
  }
}

export default Services
